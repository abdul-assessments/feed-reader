# Introduction 
Welcome to the BBC News Rss Feed Archiver. It not only shows you the current news feed, but also stores them to your local disk as json.

# Prerequisites
* [.Net 5 SDK](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.101-windows-x64-installer)


## Built Using
* Angular CLI
* [SyndicationFeed](https://docs.microsoft.com/en-us/dotnet/api/system.servicemodel.syndication.syndicationfeed)
* Visual Studio 2019
* IISExpress

# Build and Test
1.	Clone the project and open in VS2019.
2.  The Angular app is located in /feed-reader-app/, however, the compiled scripts are referenced in the .Net app and have a target folder of /FeedReader.Api/wwwroot/app.
3.  You will need to run the .Net WebApp (FeedReader.Api). (It can be in debug mode). Since the Angular app is precompiled, you may just hit start :)

