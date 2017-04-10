# Aegis.Shp
A basic shapefile reader. Currently this reader only supports the `.shp`
and `.dbf` parts of a shapefile. It's reasonably full featured though and
at least allows you to get to the meat of the data in a an efficient way 
(especially compared to other solutions).

The shapefile reader project contains an implementation of the **Aegis** driver 
protocol so used the same way as any other data store.

# Overview
The root class is, of course, the `IDriver` implementation itself. In the case
of shapefiles this is the `Aegis.Shp.Driver` class. This is a very thin infrastructure
class so if you don't care about the driver infrastructure you can also just 
instantiate a `Aegis.Shp.Dataset` directly:

	using(var ds = Dataset.Create(@"path\to\file.shp"))
	{
		// Code using the `ds` instance
	}

Note that the shapefile driver only supports *firehose* (forward only) access for
now. This might change in the future but it should be fine for most use-case
scenarios (e.g. importing the data into a more suitable storage such as SQL Server
using `geometry` or `geography` data types).

Some datasets consist of multiple `ILayer` instances (a directory of shapefiles
or a database for example). So in order to get to the actual features we first
need to request the dataset for a layer. In the case of a single shapefile we 
can only request the one that has index zero:

	using(var ds = DataSet.Create(@"some\path.shp"))
	using(var layer = ds.GetLayer(0))
	{
		// Code using the `layer` instance
	}

Notice how both the `ds` and the `layer` instance are **disposable** but also
notice how the `ds` instance doesn't *own* the `layer` instance. The `Dataset`
instance `ds` in this case is not much more than a *factory* for `ILayer` instances.

> Once your application has an `ILayer` instance it will live in that scope - the 
> `Dataset` instance will put no effort into keeping that layer alive, for all it
> cares it doesn't even exist anymore at all right after creating it.

Anyway, now that we got ourselves an `ILayer` instance we can finally get to work. A
basic firehose loop looks more or less like this:

	while((var f = layer.GetNextFeature()) != null)
	{
		// Do something with the feature instance `f`
	}

This will give you *very fast* forward only access to all the features in the shapefile.
Bascially, this is about as much as the driver can do for now.

However, thanks to `Aegis.Dbf` we can also supply information about the data fields of
each feature, which makes this driver much more useful:

	var ld = layer.GetLayerDefinition();
	while((var f = layer.GetNextFeature()) != null)
	{
		for(var i = 0; i < ld.FieldCount; i++)
		{
			var fd = layer.GetFieldDefinition(i);
			// Using the info in `fd` you can decide how to get the field
			// from `f`. Note that `GetFieldAsString` always works.

			var s = f.GetFieldAsString(i);
			// Do something with `s` (which could be a `string` value or `null`)
		}
	}

As can be seen by its distinct lack of features the shapefile driver is still very much
in an early stage. That being said, it *should* be useful in this state even.