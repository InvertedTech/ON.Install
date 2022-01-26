const crypto = require('crypto')
const fs = require('fs')

const writeBuffer = (pb, filename) => {
	fs.writeFileSync(filename, pb)
}

module.exports = writeBuffer
