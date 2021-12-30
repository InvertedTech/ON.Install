const express = require('express')
const stripe = require('stripe')

require('dotenv').config()

const port = process.env.PORT || 4000
const server = express()

server.use(express.json())
server.use(express.urlencoded({ extended: true }))

//server.use()

server.listen(() =>
	console.log(`Payment Service (server.js)|| Listening on port:${port}...`)
)
