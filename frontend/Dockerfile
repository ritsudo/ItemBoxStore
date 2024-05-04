FROM nginx:alpine
RUN rm -rf /usr/share/nginx/html/*
COPY ./frontend/dist/. /usr/share/nginx/html
EXPOSE 80
COPY ./frontend/nginx-custom.conf /etc/nginx/conf.d/default.conf