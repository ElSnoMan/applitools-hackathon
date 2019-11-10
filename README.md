applitools-hackathon

## Issues

1. On Mac, with .NET Core, I had to install `mono-libgdiplus` for Applitools to work:

```bash
$ brew install mono-libgdiplus
```

2. Batching - The video instructions were for Java, but it kind of helped for C#.

Ultimately, I was able to ignore setting the `batch.ID` with an approach similar to this:

```c#
private BatchInfo batch;

[OneTimeSetUp]
public override void BeforeAll()
{
    batch = new Applitools.BatchInfo("Hackathon");
}

[SetUp]
public override void BeforeEach()
{
    var testName = TestContext.CurrentContext.Test.Name;
    Driver.Eyes.Current.Batch = batch;
    Driver.Eyes.Open(testName);
}
```
