// LoginAttemptList.js
import React, { useState } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = ({ login, timestamp }) => (
  <li>{`${login} - ${timestamp}`}</li>
);

const LoginAttemptList = ({ attempts = [] }) => {
  const [filter, setFilter] = useState("");

  const filteredAttempts = attempts.filter((attempt) =>
    attempt.login.toLowerCase().includes(filter.toLowerCase())
  );

  return (
    <div className="Attempt-List-Main container mt-4" style={{ maxWidth: '600px' }}>
  <p className="h5 mb-3">Recent activity</p>

  <input
    type="text"
    className="form-control form-control-sm mb-3"
    placeholder="Filter..."
    value={filter}
    onChange={(e) => setFilter(e.target.value)}
  />

  {filteredAttempts.length === 0 ? (
    <div className="border p-2 text-center">No attempts found.</div>
  ) : (
    filteredAttempts.map((attempt, index) => (
      <div
        key={index}
        className="border rounded px-3 py-2 mb-2"
        style={{ width: '100%' }}
      >
        <LoginAttempt {...attempt} />
      </div>
    ))
  )}
</div>


  );
};

export default LoginAttemptList;
