const crypto = require('crypto')
const fs = require('fs')

const writeBuffer = (call, filename) => {
	var pb = call.request.serializeBinary()
	fs.writeFileSync(filename, pb)
}

module.exports = writeBuffer
