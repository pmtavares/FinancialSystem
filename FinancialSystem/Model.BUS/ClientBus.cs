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
        private readonly Messages<Client> _message;

        public ClientBus()
        {
            _clientDao = new ClientDao();
            _message = new Messages<Client>("Client");
        }

        public string create(Client client)
        {
            bool verification = true;

            //Validate name
            string name = client.name;
            if (name == null)
            {
                //Message here
                return _message.ErrorMessageRegister(20);
            }
            else
            {
                name = client.name.Trim();
                verification = name.Length <= 30 && name.Length > 0;
                if (!verification)
                {
                    //message here
                    return _message.ErrorMessageRegister(2);
                }

            }

            //Validate address
            string address = client.address;
            if (address == null)
            {
                //Message here
                return _message.ErrorMessageRegister(60);
            }
            else
            {
                address = client.address.Trim();
                verification = address.Length <= 50 && address.Length > 0; 
                if (!verification)
                {
                    //Message here
                    return _message.ErrorMessageRegister(6);
                }

            }

            //Validate phone
            string phone = client.phone;
            if (phone == null)
            {
                //Message here
                return _message.ErrorMessageRegister(3);
            }
            else
            {
                phone = client.phone.Trim();
                verification = phone.Length <= 15 && phone.Length > 6; 
                if (!verification)
                {
                    //Message here
                    return _message.ErrorMessageRegister(35);
                }

            }

            //Check for existing
            Client objClient= new Client();
            objClient.idClient = client.idClient;

            verification = !_clientDao.find(objClient);

            if (!verification)
            {
                //Message here
                return _message.ErrorMessageRegister(8);
            }
            //end validate duplication

            
            objClient = new Client();
            objClient.pps = client.pps;

            verification = !_clientDao.findClientByPps(objClient);
            if (!verification)
            {
                //Message here
                return _message.ErrorMessageRegister(0);
            }
            //end validate pps 

            //If there is no error
            //Message here
            _clientDao.createSP(client);
            return _message.CreatedMessage("Client created!");
        }

        public void update(Client client)
        {
            bool verification = true;

            string code = client.idClient.ToString();
            long id = 0;

            if (code == null)
            {
                //Message here
                return;
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
                        return;
                    }
                }
                catch (Exception e)
                {
                    //message
                    throw e;
                }

            }

            string name = client.name;
            if (name == null)
            {
                //Message
                return;
            }
            else
            {
                name = client.name.Trim();
                verification = name.Length <= 30 && name.Length > 0;
                if (!verification)
                {
                    //message
                    return;
                }

            }

            string address = client.address;
            if (address == null)
            {
                //Message
                return;
            }
            else
            {
                address = client.address.Trim();
                verification = address.Length <= 50 && address.Length > 0;
                if (!verification)
                {
                    //Message
                    return;
                }

            }

            Client objClient = new Client();
            objClient.pps = client.pps;

            verification = !_clientDao.findClientByPps(objClient);
            if (!verification)
            {
                //Message here
                return;
            }
            //end validate pps

            //If there is error
            //Message here
            _clientDao.update(client);
            return;
        }
        public void delete(Client client)
        {
            bool verification = true;

            //verifying if exists
            Client objClient = new Client();
            objClient.idClient = client.idClient;

            verification = _clientDao.find(objClient);
            if (!verification)
            {
                return;
            }

            _clientDao.delete(objClient);
            return;
        }

        public bool find(Client objClient)
        {
            return _clientDao.find(objClient);
        }

        public List<Client> findAll()
        {
            return _clientDao.findAll();
        }
        public List<Client> findAllClients(Client objCLient)
        {
            return _clientDao.findAllClient(objCLient.name);
        }
    }
}
