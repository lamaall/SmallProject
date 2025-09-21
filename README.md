Build the Docker image

From the solution root, run:

docker build -t smallproject-api .

Run the container

docker run --rm -e ASPNETCORE_ENVIRONMENT=Development -e ASPNETCORE_URLS=http://+:5249 -p 5249:5249 smallproject-api

Once the container is running, open:

http://localhost:5249/swagger/index.html