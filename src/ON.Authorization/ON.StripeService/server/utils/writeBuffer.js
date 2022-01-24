const crypto = require('crypto')
const fs = require('fs')

const writeBuffer = (pathToPB) => {
    const wStream = fs.createWriteStream(pathToPB)
    const buffer= crypto.randomBytes(100)

    wStream.write(JSON.stringify(buffer))
    wStream.end()
}

module.exports = writeBuffer