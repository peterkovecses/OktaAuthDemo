# OktaAuthDemo
This is a demo app for Okta OpenID in Blazor WASM with a ASP.NET Core Web API Backend.

Steps:
- Create an Okta Workforce Identity Cloud registration https://developer.okta.com/signup/
- Register the application.
- Set these redirect URIs:
  https://localhost:7264/authentication/login-callback and
  https://localhost:7264/authentication/logout-callback
- In the appsettings, replace OKTADOMAIN and CLIENTID placeholders with the values obtained after registering the application with Okta.

Sign in with GitHub issue
The Okta Workforce Identity Cloud registration can be done easily with the Sign in with GitHub option, but I found that when running the application, if we also log in with a GitHub account, the redirection does not work properly, we can only navigate back to the page manually. However, after registration, it is easy to add test users, which we can use when logging into our application.
