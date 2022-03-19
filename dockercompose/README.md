## Image based docker-compose

Clone repository to desired directory

```console
git clone https://github.com/phillipfisher/ON.Install.git
```

### Services

This runs all of the api services.

Run:

```console
cd ON.Install/dockercompose/services
docker-compose up -d
```

Navigate to:  
http://localhost:8001/api/auth/index.html  
http://localhost:8001/api/cms/index.html  
http://localhost:8001/api/fakepay/index.html

### Web

This runs the old website.  Not needed but provided for reference.

Run:

```console
cd ON.Install/dockercompose/web
docker-compose up -d
```

Navigate to:
http://localhost:8002
