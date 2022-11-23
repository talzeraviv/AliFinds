import React, {useEffect, useState} from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {
  const [aliFinds, setAliFinds] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5000/api/alifinds').then(response => {
      console.log(response);
      setAliFinds(response.data);
    })
  }, [])


  return (
    <div>
      <Header as='h2' icon={'users'} content='AliFinds'/>
        <List>
          {aliFinds.map((alifind: any) => (
            <List.Item key={alifind.id}>{alifind.title}</List.Item>
          ))}
        </List>
    </div>
  );
}

export default App;
