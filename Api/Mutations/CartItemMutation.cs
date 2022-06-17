using System;
using Core.Entities;
using Core.Repositories;
using HotChocolate.Subscriptions;

namespace Api.Mutations
{
    [ExtendObjectType(Name = "Mutation")]

    public class CartItemMutation
    {
        private readonly ILogger<CartItemMutation> _logger;
        public CartItemMutation(ILogger<CartItemMutation> logger)
        {
            _logger = logger;
        }

        public async Task<CartItem> CreateCartItemAsync(string productId, string userId, int quantity, string sessionId,

            [Service] ICartItemRepository cartItemRepository, [Service] IShoppingSessionRepository sessionRepository, [Service] IProductRepository productRepository, [Service] ITopicEventSender eventSender)
        {
            ShoppingSession session = await sessionRepository.GetByIdAsync(sessionId);
            Product product = await productRepository.GetByIdAsync(productId);

            List<CartItem> cartItems = await cartItemRepository.GetAllCartByUserId(userId);
            CartItem result = new CartItem();
            bool isInStore = false;
            cartItems.ForEach(cart =>
            {
                if (cart.ProductId == productId)
                {
                    _logger.LogInformation("Cart Item has been stored in database");
                    cart.Quantity = cart.Quantity + quantity;
                    isInStore = true;
                    result = cart;
                    cartItemRepository.Update(result);

                }
            });
            if (!isInStore)
            {
                _logger.LogInformation("Cart Item has not been stored in database");

                result = await cartItemRepository.InsertAsync(new CartItem(productId, userId, quantity, sessionId));

            }
            session.ModifiedAt = DateTime.Now;
            session.Total = session.Total + quantity * product.Price;
            sessionRepository.Update(session);
            return result;
        }
        public async Task<CartItem> UpdateCartItemAsync(CartItem cart,

            [Service] ICartItemRepository cartItemRepository, [Service] IShoppingSessionRepository sessionRepository,
            [Service] IProductRepository productRepository, [Service] ITopicEventSender eventSender)
        {
            try
            {
                CartItem cartInDB = await cartItemRepository.GetByIdAsync(cart.Id);
                ShoppingSession session = await sessionRepository.GetByIdAsync(cart.SessionId);

                try
                {
                    var product = await productRepository.GetByIdAsync(cart.ProductId);
                    if (product != null)
                    {

                        session.ModifiedAt = DateTime.Now;
                        session.Total = session.Total + (cart.Quantity - cartInDB.Quantity) * product.Price;
                        sessionRepository.Update(session);
                        _logger.LogInformation("Update cart item {id} ", cart.Id);
                        var result = cartItemRepository.Update(cart);
                        return result;
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError("Remove cart item {id} false . Product {productId} does not exist ", cart.Id, cart.ProductId);
                    _logger.LogError(e.ToString());
                    return null;

                }


            }
            catch (Exception e)
            {
                _logger.LogError("Update cart item {id} false . Cart Item {id} does not exist ", cart.Id);
                _logger.LogError(e.ToString());

                return null;
            }
            return null;

        }
        public async Task<CartItem> RemoveCartItemAsync(string id,

            [Service] ICartItemRepository cartItemRepository, [Service] IShoppingSessionRepository sessionRepository,
            [Service] IProductRepository productRepository, [Service] ITopicEventSender eventSender)
        {
            var cart = await cartItemRepository.GetByIdAsync(id);
            if (cart != null)
            {
                var product = await productRepository.GetByIdAsync(cart.ProductId);
                if (product != null)
                {
                    var result = await cartItemRepository.RemoveAsync(id);
                    ShoppingSession session = await sessionRepository.GetByIdAsync(cart.SessionId);

                    session.ModifiedAt = DateTime.Now;
                    session.Total = session.Total - cart.Quantity * product.Price;
                    sessionRepository.Update(session);
                    _logger.LogInformation("Remove cart item {id} ", id);
                    return cart;
                }
                else
                {
                    _logger.LogError("Remove cart item {id} false . Product {productId} does not exist ", id, cart.ProductId);
                    return null;
                }


            }
            else
            {
                _logger.LogError("Remove cart item {id} false . Cart Item {id} does not exist ", id);
                return null;
            }


        }
    }
}

