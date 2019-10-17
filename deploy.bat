dotnet publish -c Release 

cp dockerfile ./bin/release/netcoreapp2.2/publish

docker build -t tristans-app-image ./bin/release/netcoreapp2.2/publish

docker tag tristans-app-image registry.heroku.com/tristans-app/web

docker push registry.heroku.com/tristans-app/web

heroku container:release web -a tristans-app

# sudo chmod 755 deploy.sh
# ./deploy.sh