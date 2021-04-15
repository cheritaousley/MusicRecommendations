import React, { useEffect, useState } from 'react';

function App() {
  const [songName, setSongName]= useState("")
  const [albumName, setAlbumName]= useState("")
  const [artistName, setArtistName]= useState("")
  const [genre, setGenre]= useState("")
  const [isRecommended, setIsRecommended]= useState("")
  const [price, setPrice] = useState("")
  // object in current state and a function that will change it
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
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ SongName: songName, AlbumName:albumName, ArtistName:artistName, Genre: genre, Price: price, isRecommended:isRecommended  })
    });
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
          <input placeholder="What is the song name?" value={songName} onChange={(e) => setSongName(e.target.value)} />
          <input placeholder="What is the album name?" value={albumName} onChange={(e) => setAlbumName(e.target.value)} />
          <input placeholder="What is the artist name?" value={artistName} onChange={(e) => setArtistName(e.target.value)} />
        {/* change to dropdown */}
          <input placeholder="What is the genre?" value={genre} onChange={(e) => setGenre(e.target.value)} />
         {/* change to checkbox for bool */}
          <input placeholder="Do you recommend it?" value={isRecommended} onChange={(e) => setIsRecommended(e.target.value)} />
          <input placeholder="What is the price?" value={price} onChange={(e) => setPrice(e.target.value)} />
          <button type="submit">Add Recommendation</button>
        </form>
      </header>
      <section className="main" style={{ display: "block" }}>
      </section>
    </section >
  );
}

export default App;