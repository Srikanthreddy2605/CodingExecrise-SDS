import React, { useState } from "react";
import './LoginForm.css';

const LoginForm = ({ onSubmit }) => {
    const [login, setUserName] = useState('');
    const [password, setPwd] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault(); 
        
        if (!login || !password) {
            alert('Please enter details.'); 
            return; 
        }

        onSubmit({
            login,
            password,
            timestamp: new Date().toLocaleString()
        });

        setUserName('');
        setPwd('');
    };

    return (
<form
  className="mt-4 p-4 border rounded shadow-sm bg-light"
  style={{ maxWidth: '500px', margin: 'auto' }}
  onSubmit={handleSubmit}
>
  <h2 className="text-center mb-4">Login</h2>

  <div className="mb-3">
    <label htmlFor="loginName" className="form-label">Login Name</label>
    <input
      type="text"
      id="loginName"
      className="form-control"
      value={login}
      onChange={(e) => setUserName(e.target.value)}
      autoComplete="username"
      
    />
  </div>

  <div className="mb-3">
    <label htmlFor="currentPassword" className="form-label">Password</label>
    <input
      type="password"
      id="currentPassword"
      className="form-control"
      value={password}
      onChange={(e) => setPwd(e.target.value)}
      autoComplete="current-password"
      
    />
  </div>

  <button type="submit" className="btn btn-primary w-100">Continue</button>
</form>

    );
};

export default LoginForm;