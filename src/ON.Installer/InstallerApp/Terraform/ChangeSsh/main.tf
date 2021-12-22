variable ipaddress {}
variable username {}
variable tempSshPriv {}
variable sshPub {}

resource null_resource changeSshKey {
  provisioner remote-exec {
    inline = [
      "sudo echo \"${var.sshPub}\" >> ~/.ssh/authorized_keys",
    ]
  }

  connection {
    host     = var.ipaddress
    type     = "ssh"
    user     = var.username
    private_key = var.tempSshPriv
    agent    = "false"
  }
}
