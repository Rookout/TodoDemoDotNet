Remove-Item bin -Recurse 
docker build -f build.Dockerfile -t todo-demo-dotnet-assets .

docker create --name todo-demo-dotnet-assets-1 todo-demo-dotnet-assets

docker cp todo-demo-dotnet-assets-1:C:\\build\\bin .\\bin
docker rm todo-demo-dotnet-assets-1

docker build -f Dockerfile -t todo-demo-dotnet:0.1 .