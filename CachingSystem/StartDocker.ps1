$imageName = "my_redis"
$containerName = "my_redis_container"

docker build -t $imageName .
docker run -d $imageName -name $containerName

# docker images
# docker rmi