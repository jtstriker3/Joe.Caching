Joe.Caching
===========

Light weight caching Library that defaults to an in memory cache but can be easy expanded to use any source to store cached data. Uses delegates to unobtrusively refresh the cache when needed. The cached objects will be stored via a combination of the passed in key and the parameter values passed in. Allowing you to cache multiple list of objects for one key based on the parameters passed to the cache. 
