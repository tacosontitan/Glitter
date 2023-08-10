// using System;
// using System.Collections.Generic;
// using Xunit;
//
// namespace Glitter.Persistence.Tests;
//
// public class SessionBagTests
// {
//     [Fact]
//     public void CanAddAndGetNamedValue()
//     {
//         // Arrange
//         var bag = new SessionBag();
//         string key = "myKey";
//         string value = "myValue";
//
//         // Act
//         bag[key] = value;
//         object? result = bag[key];
//
//         // Assert
//         Assert.Equal(value, result);
//     }
//
//     [Fact]
//     public void CanAddAndGetTypedValue()
//     {
//         // Arrange
//         var bag = new SessionBag();
//         var value = new List<int> { 1, 2, 3 };
//
//         // Act
//         bag.Set(value);
//         List<int>? result = bag.Get<List<int>>();
//
//         // Assert
//         Assert.Equal(value, result);
//     }
//
//     [Fact]
//     public void CanResolveServiceProvider()
//     {
//         // Arrange
//         var serviceProvider = new TestServiceProvider();
//         var bag = new SessionBag(serviceProvider);
//
//         // Act
//         TestService? result = bag.Get<TestService>();
//
//         // Assert
//         Assert.NotNull(result);
//         _ = Assert.IsType<TestService>(result);
//     }
//
//     private sealed class TestServiceProvider : IServiceProvider
//     {
//         public object? GetService(Type serviceType) =>
//             serviceType == typeof(TestService) ? new TestService() : null;
//     }
//
//     private sealed class TestService { }
// }
