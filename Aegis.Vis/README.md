# Aegis.Vis
A collection of utilities and adapters for `Aegis.Data` to help making sense of 
of data generally and also to make it easy to *scaffold* new styles for your
datasets.

# Introduction
The main focus of the `Vis` project is to provide an adapter into `Aegis.Data` and
streamline the styling of your datasets.

As a side-effect of that, some interresting utilities have evolved. So currently
the package focusses on a few key features:

* Classification of data
* Visualisation of data
* Integration with `Aegis.Data`

# Overview
This provides a high level overview of what is in the `Vis` project. For the 
quick summary we have these bullet points:

* Removal of *outliers* using **Chauvenet's criterion**
* Classification of datasets using **nested means**, categorized, single symbols algorithms
* Scaffold `StyleClass` instances to be consumed by `Aegis.Data` for storage
* Create colorized legends using a **flexible** but **simple** interface or make use of the builtin `GradientColor`, `RandomColor` or `SingleColor` *color ramps* (more to follow in future updates).
* Analyze data using **Math.NET Numerics** from the command line (this hooks into the `aegis` executable)

There's a lot more to the `Vis` project though. 