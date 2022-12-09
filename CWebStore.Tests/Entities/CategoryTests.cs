﻿namespace CWebStore.Tests.Entities;

[TestClass]
public class CategoryTests
{
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_a_string_empty_category_name_should_return_IsNotNullOrEmpty_error_message()
    {
        var category = new Category(new CategoryName(string.Empty));
        var message = "Category name must not be null or empty.";
        Assert.AreEqual(message, category.Notifications.First().Message);
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_a_valid_category_EditCategoryName_with_string_empty_should_return_error_message()
    {
        var category = new Category(new CategoryName("Category name"));
        category.EditCategoryName(string.Empty);
        var message = "Category name must not be null or empty.";
        Assert.AreEqual(message, category.Notifications.First().Message);
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_a_valid_category_should_return_IsValid()
    {
        var category = new Category(new CategoryName("Category name"));
        Assert.IsTrue(category.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_a_valid_category_EditCategoryName_with_valid_name_should_return_IsValid()
    {
        var category = new Category(new CategoryName("Category name"));
        category.CategoryName.EditCategoryName("New category NameValueObject");
        Assert.IsTrue(category.IsValid);
    }
}

