# Aegis.Sfa
This is a bare-bones implementation of a generic *simple feature access* API.
The goal is to provide an API that allows creating data programmatically easily
and efficiently. 

This layer is also useful as an adapter/utility for whatever driver you plan to
write for the **Aegis** kernel. In fact, the `Aegis.Shp` driver depends on 
`Aegis.Sfa` to translate from the ancient *shapefile* format to a more modern
**WKT** or **WKB** representation.
