# Aegis.Dbf
This is a very basic `.dbf` reader for shapefiles.

Some useful links about the DBF format:

* http://dbase.com/Knowledgebase/INT/db7_file_fmt.htm
* http://web.archive.org/web/20150323061445/http://ulisse.elettra.trieste.it/services/doc/dbase/DBFstruct.htm

Note that not all `.dbf` files are equal and this code might or might not work with your 
particular flavor of DBF. When you run into problems, the spec will be useful.
    
# Usage
Creating a `DbfReader` is super easy. Just open a stream to a `.dbf` file and use the
`Create` method to obtain an instance:

	using(var stream = File.OpenRead(@"some:\dbase\file.dbf"))
	using(var reader = DbfReader.Create(stream))
	{
		// Some code using the reader instance
	}

Once you got a `DbfReader` instance you get request the number of records:

	var count = reader.NumRecords;

You can get meta-info about the fields via the `FieldDescriptors` property. 
This is an array of `FieldDescriptor` objects that contain information relating
to data type, precision and formatting.

You get random access to any record using the `GetRecord` method:

	var record = reader.GetRecord(123);

The contents of the record will be returned as an `IDictionary<string,string>` object
but you can get stronger typed results out of it by using that in conjunction with
the `FieldDescriptors` property.

# Example
Below is a small example how it all fits together in a more complete scenario. The 
code below demonstratos how you would typically use the reader in a more service
oriented class:

	public static IDictionary<string,object> GetRecord(int index)
	{
		using(var stream = File.OpenRead(@"path/to/dbf"))
		using(var reader = DbfReader.Create(stream))
		{
			var fields = reader.FieldDescriptors;
			var rec = reader.GetRecord(index);
			return fields.ToDictionary(
				x => x.FieldName,
				x => GetValue(x, rec[x.FieldName]));
		}
	}

	private static object GetValue(string value, FieldDescriptor field)
	{
		// Code to convert `value` to some object using info from `field`
	}

The `GetValue` method is omitted because usually it's just a boring `switch`
that, depending on the value of `FieldType`, deserializes the given string value.