using Model.BUS.Util;
using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;


namespace Model.BUS
{
    public class ClientBus
    {

        private readonly ClientDao _clientDao;
        private readonly IMessages<Client> _message;

        public ClientBus()
        {
            _clientDao = new ClientDao();
            _message = new ClientMessages("Client");
        }

        public string create(Client client)
        {
            bool verification = true;

            //Validate name
            string name = client.name;
            if (name == null)
            {
                //Message here
                return _message.ErrorMessages(20);
            }
            else
            {
                name = client.name.Trim();
                verification = name.Length <= 30 && name.Length > 0;
                if (!verification)
                {
                    //message here
                    return _message.ErrorMessages(2);
                }

            }

            //Validate address
            string address = client.address;
            if (address == null)
            {
                //Message here
                return _message.ErrorMessages(60);
            }
            else
            {
                address = client.address.Trim();
                verification = address.Length <= 50 && address.Length > 0; 
                if (!verification)
                {
                    //Message here
                    return _message.ErrorMessages(6);
                }

            }

            //Validate phone
            string phone = client.phone;
            if (phone == null)
            {
                //Message here
                return _message.ErrorMessages(3);
            }
            else
            {
                phone = client.phone.Trim();
                verification = phone.Length <= 15 && phone.Length > 6; 
                if (!verification)
                {
                    //Message here
                    return _message.ErrorMessages(35);
                }

            }

            string pps = client.pps;
            if (pps == null)
            {
                //Message
                return _message.ErrorMessages(50); ;
            }
            else
            {
                pps = client.pps.Trim();
                verification = pps.Length <= 9 && pps.Length > 7;
                if (!verification)
                {
                    //Message
                    return _message.ErrorMessages(55);
                }

            }

            //Check for existing
            Client objClient= new Client();
            objClient.idClient = client.idClient;

            Client findClient = _clientDao.find(objClient.idClient);

            if (findClient == null)
            {
                //Message here
                return _message.ErrorMessages(8);
            }
            //end validate duplication

            
            objClient = new Client();
            objClient.pps = client.pps;

            verification = !_clientDao.findClientByPps(objClient);
            if (!verification)
            {
                //Message here
                return _message.ErrorMessages(58);
            }
            //end validate pps 

            //If there is no error
            //Message here
            _clientDao.createSP(client);
            return _message.SuccessMessage("Ok");
        }

        public string update(Client client)
        {
            bool verification = true;
            Client clientToUpdate = new Client();

            string code = client.idClient.ToString();
            long id = 0;

            if (code == null)
            {
                //Message here
                return _message.ErrorMessages(9);
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(client.idClient);
                    verification = code.Length > 0 && code.Length < 999999; 


                    if (!verification)
                    {
                        //message here
                        return _message.ErrorMessages(0);
                    }
                }
                catch (Exception e)
                {
                    //message
                    throw e;
                }

            }

            clientToUpdate.name = client.name;
            if (clientToUpdate.name == null)
            {
                //Message
                return _message.ErrorMessages(20);
            }
            else
            {
                clientToUpdate.name = client.name.Trim();
                verification = clientToUpdate.name.Length <= 30 && clientToUpdate.name.Length > 0;
                if (!verification)
                {
                    //message
                    return _message.ErrorMessages(2);
                }

            }

            clientToUpdate.address = client.address;
            if (clientToUpdate.address == null)
            {
                //Message
                return _message.ErrorMessages(60);
            }
            else
            {
                clientToUpdate.address = client.address.Trim();
                verification = clientToUpdate.address.Length <= 50 && clientToUpdate.address.Length > 0;
                if (!verification)
                {
                    //Message
                    return _message.ErrorMessages(6); ;
                }

            }

            clientToUpdate.pps = client.pps;
            if (clientToUpdate.pps == null)
            {
                //Message
                return _message.ErrorMessages(50);
            }
            else
            {
                clientToUpdate.pps = client.pps.Trim();
                verification = clientToUpdate.pps.Length <= 9 && clientToUpdate.pps.Length > 7;
                if (!verification)
                {
                    //Message
                    return _message.ErrorMessages(55);
                }

            }

            //verification = _clientDao.findClientByPps(client);
            //if (!verification)
            {
                //Message here
              //  return _message.ErrorMessages(59);
            }
            //end validate pps
            clientToUpdate.phone = client.phone;
            if (clientToUpdate.phone == null)
            {
                //Message here
                return _message.ErrorMessages(3);
            }
            else
            {
                clientToUpdate.phone = client.phone.Trim();
                verification = clientToUpdate.phone.Length <= 15 && clientToUpdate.phone.Length > 6;
                if (!verification)
                {
                    //Message here
                    return _message.ErrorMessages(35);
                }

            }

            //If there is error
            //Message here
            clientToUpdate.idClient = client.idClient;
            _clientDao.updateSP(clientToUpdate);
            return _message.SuccessMessage("Ok");
        }
        public string delete(long id)
        {
            Client client = new Client();

            //verifying if exists
            //Client objClient = new Client();
            //objClient.idClient = client.idClient;

            client = _clientDao.find(id);
            if (client == null)
            {
                return _message.ErrorMessages(95);
            }

            _clientDao.delete(client);
            return _message.SuccessMessage("Message Deleted");
        }

        public Client find(long id)
        {
            return _clientDao.find(id);
        }

        public List<Client> findAll()
        {
            return _clientDao.findAll();
        }
        public List<Client> findAllClients(string clientName, string clientCode, string clientPps)
        {

            if(clientCode == "" || clientCode is null)
            {
                clientCode = "0";
            }

            if(clientPps == "" || clientPps is null)
            {
                clientPps = "0";
            }

            if (clientName == "" && (clientPps == "0" || clientCode == "0"))
            {
                return _clientDao.findAll();
            }
            return _clientDao.findAllClient(clientName, clientCode, clientPps);
        }
    }
}
