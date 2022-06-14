﻿using System;
using Core.Entities;
using Core.Repositories;
using HotChocolate.Subscriptions;

namespace Api.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class ProductMutation
    {

        public async Task<Product> CreateProductAsync(string name, string description, string discountId, string sku, decimal price, bool isEmpty, string categoryId, string image,


            [Service] IProductRepository productRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await productRepository.InsertAsync(new Product(name, description, discountId,  sku, price,  isEmpty,  categoryId,  image));

            //await eventSender.SendAsync(nameof(Subscriptions.ProductSubscriptions.OnCreateAsync), result);

            return result;
        }

        public async Task<bool> RemoveProductAsync(string id, [Service] IProductRepository productRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await productRepository.RemoveAsync(id);

            if (result)
            {
                //await eventSender.SendAsync(nameof(Subscriptions.ProductSubscriptions.OnRemoveAsync), id);
            }

            return result;
        }
    }
}

