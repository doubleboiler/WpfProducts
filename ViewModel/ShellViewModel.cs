﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WpfProductsData.Repositories;
using WpfProductsTest.ViewModel.Base;
using WpfProdutcs.Models;
using WpfProdutcs.Models.Dtos;

namespace WpfProductsTest.ViewModel
{
    public class ShellViewModel:ViewModelBase
    {
        private Product _product;
        private readonly IRepository<Product> _productRepository;

        public ShellViewModel(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            GetData();
        }
        public string Title { get; set; } = "WPF Product App";
        public ObservableCollection<ProductDto> Products { get; set; }
        public Product Product { get => _product; set { _product = value; OnPropertyChanged(); } }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand NewCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand GetJsonCommand { get; set; }
        public DelegateCommand LoadJsonCommand { get; set; }
        public DelegateCommand<ProductDto> SelectionChangedCommand { get; set; }

        protected override void RegisterCommands()
        {
            SaveCommand = new DelegateCommand(Save);
            NewCommand = new DelegateCommand(New);
            SelectionChangedCommand = new DelegateCommand<ProductDto>(SelectionChanged);
            DeleteCommand = new DelegateCommand(Delete);
            GetJsonCommand = new DelegateCommand(SerializeJson);
            LoadJsonCommand = new DelegateCommand(DeserializeJson);
        }

        private void Delete()
        {
            _productRepository.Delete(Product.Id);
            var productToDelete = Products.Single(x => x.Id == Product.Id);
            Products.Remove(productToDelete);
        }

        private void SelectionChanged(ProductDto productDto)
        {
            if (productDto != null)
            {
                var product = _productRepository.Get(productDto.Id);
                Product = product;
            }
            else
            {
                Product = null;
            }
        }

        private void New()
        {
            Product = new Product();
        }

        private void GetData()
        {
            var products = _productRepository
                .Get()
                .OrderBy(x=>x.Name)
                .Select(product=>new ProductDto()
                {
                    Id=product.Id,
                    ProductCode=product.ProductCode,
                    Name=product.Name
                })
                .ToList();
            Products.AddRange(products);
        }
        private void SerializeJson()
        {
            var getPath = @"C:\Users\biriukov\Documents\jsonproducts.txt";
            var jsonProducts = JsonConvert.SerializeObject(_productRepository.Get());
            System.IO.File.WriteAllText(getPath, jsonProducts);
        }
        private void DeserializeJson()
        {
            var loadPath = @"C:\Users\biriukov\Documents\jsonproductstoload.txt";

            try
            {
                var newProducts = JsonConvert.DeserializeObject<Product[]>(System.IO.File.ReadAllText(loadPath));
                foreach (var product in newProducts)
                {
                    _productRepository.Save(product);
                }
            }
            catch (JsonSerializationException)
            {
                throw new InvalidOperationException("Ошибка в файле");
            }

        }
        protected override void RegisterCollections()
        {
            Products = new ObservableCollection<ProductDto>();
        }
        private void Save()
        {
            _productRepository.Save(Product);
            Products.Add(new ProductDto() { Id = Product.Id, ProductCode = Product.ProductCode, Name = Product.Name });
        }
    }
}
