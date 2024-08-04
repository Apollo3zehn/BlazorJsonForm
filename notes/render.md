The rendering algorithm works in the following way:

- Check the current schema and select a proper sub-render method
- In case of an object, render all properties
- Whenever the backing `JsonNode` for a specific object property is null and the property itself does not allow null, it will be created and returned to the calling method
- The calling method is responsible to properly replace the null value with the new value in the parent `JsonNode`
- So the rendering process is also sometimes modifying the data store (`json`) which means a re-render of the `BlazorJsonFormTester` page is needed so that the JSON data display is up-to-date
- Whenever data is changed by a user, a method named `setValue` passed by the caller will be invoked, which ensures the new value will become part of the data store
- This method raises the `DataChanged` event to trigger another re-render of the whole `BlazorJsonFormTester` page