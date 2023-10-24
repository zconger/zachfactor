# zachfactor

A .Net test app for Azure Active Directory testing

* Created from the tutorial, Azure AD OAuth client credential flow with custom certificate walk-through ([link](https://nicolgit.github.io/azure-ad-oauth-client-credential-flow-certificate-walk-through/))
* My Zachfactor Azure app registration ([link](https://portal.azure.com/#view/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/~/Overview/quickStartType~/null/sourceType/Microsoft_AAD_IAM/appId/d4b58aba-58c7-4e58-a604-b4d7c0b8f7f5/objectId/af065248-dcfa-4eb6-b969-d4cf9a68f677/isMSAApp~/false/defaultBlade/Overview/appSignInAudience/AzureADMyOrg/servicePrincipalCreated~/true))
* zachfactor.cs - working .Net 6 app to auth and get a token from the auth service
* stackhawk.yml - HawkScan config that attempts to leverage auth script in hawkscripts
* hawkscripts/authentication/aad-cc-cert-auth.kts - a mutilated copy of Dana's AAD-CCC auth script
* keyster-zachlock-20231021.pfx - key and cert
* zachfactor.signing.crt - key and cert, PEM file edition
* The "Zachfactor" application registration from Azure AD Overview UI:
  * Display name: Zachfactor
  * Application (client) ID: d4b58aba-58c7-4e58-a604-b4d7c0b8f7f5
  * Object ID: af065248-dcfa-4eb6-b969-d4cf9a68f677 
  * Directory (tenant) ID: ca346305-52ed-45ea-8064-3c4e8196ea12
  * Supported account types: My organization only
  * Client credentials: 1 certificate, 0 secret (see Azure AD Certificate Info below)
  * Application ID URI: api://d4b58aba-58c7-4e58-a604-b4d7c0b8f7f5
  * Managed application in local directory: Zachfactor
* Azure AD Certificate Info from Azure AD UI:
  * Thumbprint: E88F5E7F800C725F303106CF04D8C90AF6C1044C
  * Description: CN=zachlock
  * Start date: 10/20/2023
  * Expires: 10/20/2024
  * Certificate ID: 9e60505d-5d5b-4647-b981-f9dcf2ed48e7
