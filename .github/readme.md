# Kubernetes + ASP.NET CORE example

A small repository explaining on how to build docker, kubernetes and asp.net core together. Please follow the set up steps below if you'd like to deploy to your own kubernetes cluster.

## File structure

```bash
.
|  manifests
   |  deployment.yml                     # kubernetes file that defines the pod and docker image to deploy.
   |  ingress.yml                        # kubernetes file that creates routes to the outside, requires either a load balancer internally.
   |  service.yml                        # service definitions to map the deployed pods under.
|  src
|  |  ExampleService
      |  Dockerfile                      # file containing all specific docker instructions to build a docker image.  
      |  ExampleService.csproj
      |  Program.cs
      |  Startup.cs
|  .dockerignore                         # list of files to ignore when creating a docker file. Similar to .gitignore
|  .gitignore                            
|  ExampleService.sln 
```

## Set up

### Pushing your docker file

Navigate to the docker file
```
cd src/ExampleService
```

Log in to your docker hub account
```
docker login -u {USERNAME}
```

Build the docker file and tag it to `exampleservice:latest`
```
docker build -t exampleservice:latest .
```

Push the file to docker.io [Required you to be logged in]
```
docker push {USERNAME}/exampleservice:latest
```

### Applying changes to Kubernetes

[OPTIONAL] get a kubernetes cluster and apply its config to your machine.
- I recommend getting a temporary [DigitalOcean managed kubernetes](https://www.digitalocean.com/products/kubernetes/) service if you're interested in following these steps.
- Tutorial on [connecting to a specific context](https://www.digitalocean.com/docs/kubernetes/how-to/connect-to-cluster/)
- Setting up an [ingress controller for Digitalocean](https://www.digitalocean.com/community/tutorials/how-to-set-up-an-nginx-ingress-on-digitalocean-kubernetes-using-helm)

Move to the manifests folder
```
cd manifests
```

Apply all files to your kubernetes pod.
```
kubectl apply -f .
```

Once you go to your loadbalancer's IP and do `{IP}/test` It should respond with "Hello, this is the machine named {POD ID}".
