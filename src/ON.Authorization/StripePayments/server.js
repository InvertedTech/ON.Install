const express = require('express')
const stripe = require('stripe')

require('dotenv').config()

const port = process.env.PORT || 4000
const app = express()

app.listen(() => console.log(`Listening on port:${port}`))
