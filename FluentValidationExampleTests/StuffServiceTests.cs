using FluentValidationExample.Entities;
using FluentValidationExample.Services;

namespace FluentValidationExampleTests;

public class StuffServiceTests
{
  [Fact]
  public void Constructor_InitializesEmptyList()
  {
    var service = new StuffService();

    var result = service.GetAllTheStuff();

    Assert.NotNull(result);
    Assert.Empty(result);
  }

  [Fact]
  public void GetAllTheStuff_ReturnsEmptyList_WhenNoStuffAdded()
  {
    var service = new StuffService();

    var result = service.GetAllTheStuff();

    Assert.Empty(result);
  }

  [Fact]
  public void GetAllTheStuff_ReturnsAllItems_WhenStuffAdded()
  {
    var service = new StuffService();
    var stuff1 = new Stuff { Id = Guid.NewGuid(), Name = "Test1" };
    var stuff2 = new Stuff { Id = Guid.NewGuid(), Name = "Test2" };
    service.AddStuff(stuff1);
    service.AddStuff(stuff2);

    var result = service.GetAllTheStuff();

    Assert.Equal(2, result.Count);
    Assert.Contains(stuff1, result);
    Assert.Contains(stuff2, result);
  }

  [Fact]
  public void GetStuffById_ReturnsNull_WhenIdNotFound()
  {
    var service = new StuffService();
    var nonExistentId = Guid.NewGuid();

    var result = service.GetStuffById(nonExistentId);

    Assert.Null(result);
  }

  [Fact]
  public void GetStuffById_ReturnsCorrectItem_WhenIdExists()
  {
    var service = new StuffService();
    var stuffId = Guid.NewGuid();
    var stuff = new Stuff { Id = stuffId, Name = "TestStuff" };
    service.AddStuff(stuff);

    var result = service.GetStuffById(stuffId);

    Assert.NotNull(result);
    Assert.Equal(stuffId, result.Id);
    Assert.Equal("TestStuff", result.Name);
  }

  [Fact]
  public void GetStuffById_ReturnsCorrectItem_WhenMultipleItemsExist()
  {
    var service = new StuffService();
    var stuff1 = new Stuff { Id = Guid.NewGuid(), Name = "Test1" };
    var stuff2 = new Stuff { Id = Guid.NewGuid(), Name = "Test2" };
    var stuff3 = new Stuff { Id = Guid.NewGuid(), Name = "Test3" };
    service.AddStuff(stuff1);
    service.AddStuff(stuff2);
    service.AddStuff(stuff3);

    var result = service.GetStuffById(stuff2.Id);

    Assert.NotNull(result);
    Assert.Equal(stuff2.Id, result.Id);
    Assert.Equal("Test2", result.Name);
  }

  [Fact]
  public void AddStuff_ReturnsTrue_WhenStuffAdded()
  {
    var service = new StuffService();
    var stuff = new Stuff { Id = Guid.NewGuid(), Name = "TestStuff" };

    var result = service.AddStuff(stuff);

    Assert.True(result);
  }

  [Fact]
  public void AddStuff_AddsItemToList()
  {
    var service = new StuffService();
    var stuff = new Stuff { Id = Guid.NewGuid(), Name = "TestStuff" };

    service.AddStuff(stuff);

    var allStuff = service.GetAllTheStuff();
    Assert.Single(allStuff);
    Assert.Contains(stuff, allStuff);
  }

  [Fact]
  public void AddStuff_AddsMultipleItems()
  {
    var service = new StuffService();
    var stuff1 = new Stuff { Id = Guid.NewGuid(), Name = "Test1" };
    var stuff2 = new Stuff { Id = Guid.NewGuid(), Name = "Test2" };

    service.AddStuff(stuff1);
    service.AddStuff(stuff2);

    var allStuff = service.GetAllTheStuff();
    Assert.Equal(2, allStuff.Count);
  }

  [Fact]
  public void RemoveStuff_ReturnsTrue_WhenItemExists()
  {
    var service = new StuffService();
    var stuffId = Guid.NewGuid();
    var stuff = new Stuff { Id = stuffId, Name = "TestStuff" };
    service.AddStuff(stuff);

    var result = service.RemoveStuff(stuffId);

    Assert.True(result);
  }

  [Fact]
  public void RemoveStuff_RemovesItemFromList()
  {
    var service = new StuffService();
    var stuffId = Guid.NewGuid();
    var stuff = new Stuff { Id = stuffId, Name = "TestStuff" };
    service.AddStuff(stuff);

    service.RemoveStuff(stuffId);

    var allStuff = service.GetAllTheStuff();
    Assert.Empty(allStuff);
  }

  [Fact]
  public void RemoveStuff_RemovesCorrectItem_WhenMultipleItemsExist()
  {
    var service = new StuffService();
    var stuff1 = new Stuff { Id = Guid.NewGuid(), Name = "Test1" };
    var stuff2 = new Stuff { Id = Guid.NewGuid(), Name = "Test2" };
    var stuff3 = new Stuff { Id = Guid.NewGuid(), Name = "Test3" };
    service.AddStuff(stuff1);
    service.AddStuff(stuff2);
    service.AddStuff(stuff3);

    service.RemoveStuff(stuff2.Id);

    var allStuff = service.GetAllTheStuff();
    Assert.Equal(2, allStuff.Count);
    Assert.Contains(stuff1, allStuff);
    Assert.DoesNotContain(stuff2, allStuff);
    Assert.Contains(stuff3, allStuff);
  }

  [Fact]
  [Trait("Category", "SkipWhenLiveUnitTesting")]
  public void RemoveStuff_ThrowsException_WhenIdNotFound()
  {
    var service = new StuffService();
    var nonExistentId = Guid.NewGuid();

    Assert.Throws<InvalidOperationException>(() => service.RemoveStuff(nonExistentId));
  }
}