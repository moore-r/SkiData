# SkiData
SkiData challenge

Angular SPA gets user input for registering an account. Posts data to .net core app that then properly serializes it and sends it to the SKI test portal to create a user. A success message and user ID is then sent back through the net core app to be displayed to the user on the Angular site.

.Net Core app uses version 2.1. Has added nuget packages: swashbuckle for swagger UI, Restsharp to make restful aPI calls, and newtonsoft.json to serialize and deserialize data. 

Angular app uses version 6 with no significant added modules. I would normally use material, but ran into a few versioning issues with Angular 6 and decided I'd just keep it simple as this spa only has one component. 

