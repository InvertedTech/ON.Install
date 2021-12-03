terraform {
  required_providers {
    digitalocean = {
      source = "digitalocean/digitalocean"
      version = "~> 2.0"
    }
  }
}

#variable "pvt_key" {}

provider "digitalocean" {
  token = var.do_token
}

data "digitalocean_ssh_key" "terraform" {
  name = "${var.prefix}-key"
  public_key = file("../../ssh.pub")
}

resource "digitalocean_droplet" "vm1" {
  image = "docker-20-04"
  name = "${var.prefix}-vm-1"
  region = "nyc3"
  size = "s-1vcpu-1gb"
  ssh_keys = [
    data.digitalocean_ssh_key.terraform.id
  ]

  # connection {
  #   host = self.ipv4_address
  #   user = var.username
  #   type = "ssh"
  #   private_key = file("../../ssh.priv")
  #   timeout = "2m"
  # }

  # provisioner "remote-exec" {
  #   inline = [
  #     "export PATH=$PATH:/usr/bin"
  #     # install nginx
  #     #"sudo apt update",
  #     #"sudo apt install -y nginx"
  #   ]
  # }
}