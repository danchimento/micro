FROM nginx

#TODO: Figure out how to have the conf dropped in during the build
# COPY conf /etc/nginx 

# FROM alpine:3.8 AS generate
# WORKDIR /certificates
# RUN apk update && \
#     apk add --no-cache openssl && \
#     rm -rf /var/cache/apk/*
# RUN openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout sampleapp.key -out sampleapp.crt -subj "/C=GB"

# FROM nginx:1.15.8-alpine
# EXPOSE 443
# COPY Micro.Gateway/nginx.conf /etc/nginx/nginx.conf
# COPY --from=generate /certificates/sampleapp.key /certificates/sampleapp.crt /etc/nginx/ssl/