﻿using System.Text;

namespace CWebStore.Tests.ValueObjects;

[TestClass]
public class UrlStringTests
{
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_url_should_return_IsGreaterThan_error_message()
    {
        var great = new StringBuilder("aaaaaaaa10aaaaaaaa20aaaaa32chars");
        var finalGreat = new StringBuilder("https://url.com/has26chars?");
        for (var i = 64; i > 0; i--)
            finalGreat.Append(great);
        var urlString = new UrlString(finalGreat.ToString());
        var message = "Url must have 2048 or less characters.";
        var urlStringError = urlString.Notifications.First();
        Assert.AreEqual(message, urlStringError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_url_should_return_IsNotUrlOrEmpty_error_message()
    {
        var urlString = new UrlString(string.Empty);
        var message = "This is not a valid Url.";
        var urlStringError = urlString.Notifications.First();
        Assert.AreEqual(message, urlStringError.Message);
    }
    
    [TestMethod]
    [TestCategory("ProductApi.ValueObjects")]
    public void Given_a_url_should_return_IsNotUrl_error_message()
    {
        var urlString = new UrlString("this_is_not_a_valid_url_string_test");
        var message = "This is not a valid Url.";
        var urlStringError = urlString.Notifications.First();
        Assert.AreEqual(message, urlStringError.Message);
    }
}