var grpc = require('grpc')
const { v4: uuidv4 } = require('uuid')

// var services = require('../server/proto/dummy_grpc_pb')
var service = require('../server/proto/stripe_grpc_pb')
var StripeService = require('../server/proto/stripe_pb')

// TODO: Check typeof(data) === json
// function buildData(data) {
// 	var stripeData = new StripeService.StripeData()
// 	stripeData.setCreated(data.created)
// 	stripeData.setSubscriptionitems(data.subscriptionItems)
// 	stripeData.setCustomers(data.customers)
// 	stripeData.setSubscriptions(data.subscriptions)

// 	return stripeData
// }

// TODO: Check typeof(data) === json
// function buildRequest(requestData) {
// 	return new StripeService.StripeRequest(requestData)
// }

function main() {
	// Define the client
	var client = new service.StripeServiceClient(
		'localhost:50051',
		grpc.credentials.createInsecure()
	)

	var timestamp = Date.now()

	// Build the data
	// TODO: Dynamic data in production
	var stripeData = new StripeService.StripeData()
	stripeData.setCreated(timestamp.toString())
	stripeData.setSubscriptionitemsList()
	stripeData.setCustomersList()
	stripeData.setSubscriptionsList()

	// Create instance of StripeID
	var stripeId = new StripeService.StripeId()
	stripeId.setStripeid('pub key')

	// Create Request
	var request = new StripeService.StripeRequest()
	request.setId(uuidv4())
	request.setCreated(Date.now())
	request.setStripeid(stripeId)
	request.setStripedata(stripeData)

	// Call the WriteStripeData service
	client.writeStripeData(request, (error, response) => {
		if (!error) {
			console.log('Stripe Response: ' + response.getResponsemessage())
		} else {
			console.log('error')
			console.error(error)
		}
	})
}

main()
