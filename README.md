# Aegis
**Aegis** is a modern toolkit for implementing **geographic information systems** that is
written from the ground up for .NET. It strives to be low on dependencies and faithful to
established standards that work such as **WKT**, **WKB**, **GeoJSON**, **Shapefiles** and 
more. 

It's extensible so if implement a driver for your data source you can hook in all kinds of 
things that might not be supported out of the box.

The interface is heavily inspired by the fabulous **GDAL** toolkit but the implementation
is independent. Also, **Aegis** is in a lot of cases *relaxed* (it doesn't babysit your data) 
and in other cases a lot more *restricted* than **GDAL** (it doesn't try to do everything).

What it **does** try to do however is to guide you in the right direction when you're
wring GIS related software.