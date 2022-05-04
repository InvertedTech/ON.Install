variable ipaddress {}
variable username {}
variable sshPriv {}

resource null_resource prepareForDockerComposeYaml {
  provisioner remote-exec {
    inline = [
      "mkdir ~/onf/",
      "mkdir ~/onf/data",
    ]
  }

  connection {
    host     = var.ipaddress
    type     = "ssh"
    user     = var.username
    private_key = var.sshPriv
    agent    = "false"
  }
}

resource null_resource copyDockerComposeYaml {

  provisioner file {
    source      = "docker-compose.yml"
    destination = "~/onf/docker-compose.yml"
  }

  connection {
    host     = var.ipaddress
    type     = "ssh"
    user     = var.username
    private_key = var.sshPriv
    agent    = "false"
  }

  depends_on = [
    null_resource.prepareForDockerComposeYaml,
  ]
}

resource null_resource copyJson {

  provisioner file {
    source      = "defaults.json"
    destination = "~/onf/data/defaults.json"
  }

  connection {
    host     = var.ipaddress
    type     = "ssh"
    user     = var.username
    private_key = var.sshPriv
    agent    = "false"
  }

  depends_on = [
    null_resource.copyDockerComposeYaml,
  ]
}

resource null_resource runDockerComposeYaml {
  provisioner remote-exec {
    inline = [
      "cd ~/onf/",
      "sudo docker-compose up -d",
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
    null_resource.copyJson,
  ]
}
