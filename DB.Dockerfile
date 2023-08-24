FROM postgres:latest
COPY ./DB.Script /docker-entrypoint-initdb.d/
