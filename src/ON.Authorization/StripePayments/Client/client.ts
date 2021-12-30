import path from 'path'
import * as grpc from '@grpc/grpc-js'
import * as protoLoader from '@grpc/proto-loader'
import { ProtoGrpcType } from '../Proto/payment'

const PORT = process.env.PORT || 3000
const PROTO_FILE = '../Proto/payment.proto'

const packageDef = protoLoader.loadSync(path.resolve(__dirname, PROTO_FILE))
const grpcObj = grpc.loadPackageDefinition(
	packageDef
) as unknown as ProtoGrpcType
const client = new grpcObj.paymentPackage.Payment(
	`0.0.0.0:${PORT}`,
	grpc.credentials.createInsecure()
)

const deadline = new Date()
deadline.setSeconds(deadline.getSeconds() + 5)
client.waitForReady(deadline, (err) => {
	if (err) {
		console.error(err)
		return
	}

	onClientReady()
})

function onClientReady() {
	client.PingPong({ message: 'Ping' }, (err, res) => {
		if (err) {
			console.error(err)
			return
		}

		console.log(res)
	})
}
