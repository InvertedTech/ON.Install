const express = require('express')

const router = express.Router()

router.get('/subscriptions', (req, res) => {
	res.send('hello')
})

module.exports = router
