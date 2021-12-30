FROM node:12
WORKDIR "/src/ON.Authorization/StripePayments/"
COPY package.json /app
RUN npm install
COPY . .
CMD npm run start
EXPOSE 3000