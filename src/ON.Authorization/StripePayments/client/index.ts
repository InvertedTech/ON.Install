import express from 'express'

const PORT: number = parseInt(process.env.PORT) || 50050

const app: express.Application = express()

app.listen(PORT, () => {
	console.log(`Client running on port:${PORT}`)
})
