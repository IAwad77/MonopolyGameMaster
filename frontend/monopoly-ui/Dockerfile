
FROM node:20 AS build
WORKDIR /app
COPY monopoly-ui .
RUN npm install && npm run build


FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx","-g","daemon off;"]