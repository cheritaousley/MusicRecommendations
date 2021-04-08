import React, { useEffect, useState } from 'react';

function App() {
  const [songName, albumName, artistName, genre, isRecommended, price, setNewRecommendation] = useState("");
  const [recommendations, setRecommendations] = useState([]);

  async function getRecommendations() {
    const result = await fetch("/api/recommendations");
    const recommendations = await result.json();
    setRecommendations(recommendations);
  }

  async function createRecommendation(e) {
    e.preventDefault();
    await fetch('/api/recommendations', {
      method: "POST",
      body: JSON.stringify({ SongName: songName, AlbumName:albumName, ArtistName:artistName, Genre: genre, Price: price, isRecommended:isRecommended  })
    });
    setNewRecommendation("");
    await getRecommendations();
  }

  async function updateCompleted(recommendation, isComplete) {
    await fetch(`/api/recommendations/${recommendation.id}`, {
      method: "POST",
      body: JSON.stringify({ ...recommendation, isComplete: isComplete })
    });
    await getRecommendations();
  }

  async function deleteRecommendation(id) {
    await fetch(`/api/recommendations/${id}`, {
      method: "DELETE"
    });
    await getRecommendations();
  }

  useEffect(() => {
    getRecommendations();
  }, []);

  return (
    <section className="todoapp">
      <header className="header">
        <h1>Recommendations</h1>
        <form onSubmit={createRecommendation}>
          <input placeholder="What is the song name?" value={songName} onChange={(e) => setNewRecommendation(e.target.value)} />
          <input placeholder="What is the album name?" value={albumName} onChange={(e) => setNewRecommendation(e.target.value)} />
          <input placeholder="What is the artist name?" value={artistName} onChange={(e) => setNewRecommendation(e.target.value)} />
        {/* change to dropdown */}
          <input placeholder="What is the genre?" value={genre} onChange={(e) => setNewRecommendation(e.target.value)} />
         {/* change to checkbox for bool */}
          <input placeholder="Do you recommend it?" value={isRecommended} onChange={(e) => setNewRecommendation(e.target.value)} />
          <input placeholder="What is the price?" value={price} onChange={(e) => setNewRecommendation(e.target.value)} />
        </form>
      </header>
      <section className="main" style={{ display: "block" }}>
      </section>
    </section >
  );
}

export default App;