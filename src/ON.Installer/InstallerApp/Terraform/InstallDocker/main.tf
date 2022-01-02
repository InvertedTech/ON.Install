variable ipaddress {}
variable username {}
variable sshPriv {}

resource null_resource copyDockerInstallScript {

  provisioner file {
    source      = "get-docker.sh"
    destination = "/tmp/get-docker.sh"
  }

  connection {
    host     = var.ipaddress
    type     = "ssh"
    user     = var.username
    private_key = var.sshPriv
    agent    = "false"
  }
}

resource null_resource runDockerInstallScript {
  provisioner remote-exec {
    inline = [
      "sudo sh /tmp/get-docker.sh",
    ]
  }

  connection {
    host     = var.ipaddress
    type     = "ssh"
    user     = var.username
    private_key = var.sshPriv
    agent    = "false"
  }

  depends_on = [
    null_resource.copyDockerInstallScript,
  ]
}

resource null_resource copyDockerCompose {

  provisioner file {
    source      = "docker-compose"
    destination = "/tmp/docker-compose"
  }

  connection {
    host     = var.ipaddress
    type     = "ssh"
    user     = var.username
    private_key = var.sshPriv
    agent    = "false"
  }

  depends_on = [
    null_resource.runDockerInstallScript,
  ]
}

resource null_resource setupDockerCompose {
  provisioner remote-exec {
    inline = [
      "sudo cp /tmp/docker-compose /usr/local/bin/docker-compose",
      "sudo chmod +x /usr/local/bin/docker-compose",
    ]
  }

  connection {
    host     = var.ipaddress
    type     = "ssh"
    user     = var.username
    private_key = var.sshPriv
    agent    = "false"
  }

  depends_on = [
    null_resource.copyDockerCompose,
  ]
}
