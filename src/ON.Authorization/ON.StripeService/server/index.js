var grpc = require('grpc')
const { v4: uuidv4 } = require('uuid')
var fs = require('fs')

var service = require('../server/proto/stripe_grpc_pb')
var StripeService = require('../server/proto/stripe_pb')
const writeBuffer = require('./utils/writeBuffer')

// function writeData(call, callback) {
// 	let req = call.request.serializeBinary()

// 	var response = new StripeService.StripeResponse()
// 	response.setResponsemessage('server response')

// 	writeBuffer(req, 'stored.pb')

// 	callback(null, response)
// }

function createPlanRecord() {
	let plans = new StripeService.PlanList()

	fs.readFile('../plans.json', 'utf8', (error, data) => {
		if (!error) {
			plans = JSON.parse(data)
			for (element in plans) {
				let item = plans[element]
				let newPlan = new StripeService.PlanRecord()
				newPlan.setValue(item.value)
				newPlan.setName(item.name)
				newPlan.setPlanid('id')
				console.log(newPlan)
				plans.addRecords(newPlan)
			}
		} else {
			console.error(error)
		}
	})

	console.log(plans)
}

function loadPlanRecord(path) {
	let exists = fs.existsSync(path)

	if (!exists) {
		console.log('Plans not found, creating file...')
	} else {
		console.log('Plans found')
	}
}

function main() {
	var server = new grpc.Server()

	// server.addService(service.StripeServiceService, {
	// 	writeStripeData: writeData,
	// })
	server.bind('127.0.0.1:50051', grpc.ServerCredentials.createInsecure())
	server.start()

	console.log('Server running on port 127.0.0.1:50051')
}

main()
