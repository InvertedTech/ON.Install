FROM nginx:1.20.0

COPY nginx.conf.template /etc/nginx/templates/nginx.conf.template

COPY 21-move-conf.sh /docker-entrypoint.d/21-move-conf.sh
RUN chmod u+x /docker-entrypoint.d/21-move-conf.sh
