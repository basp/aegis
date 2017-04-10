# Aegis
The kernal of the **Aegis** library. This contains a relatively small number of core and utility classes that are essential for working with the rest of the libary and extensions.

# Driver 
A **driver** is a deliverable unit that can plug into **Aegis** in order to act as a **dataset** provider. Now this sounds more complicated than it is. It's just a set of interfaces and when you implement those you can call yourself an official **Aegis** driver.

Most of the kernel consists of the driver contract. But there's some utilities that help clients fulfill this contract. These are mostly contained in the `Extensions` class and most of them deal with the funkiness of some protocols.

For instance, because lots of data is bi-endian (it has *big-endian* as well as *little-endian* portions of data) we need to deal with this in a reliable way. A large part of the kernel is dedicated just to dealing with that kind of data and making it easy to consume as well as write.
