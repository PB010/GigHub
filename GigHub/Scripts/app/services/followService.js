var FollowService = function() {
	var followArtist = function (followId, done, fail) {
		$.post("/api/follows", { followedId: followId})
			.done(done)
			.fail(fail);
	};

	var unfollowArtist = function(followId, done, fail) {
		$.ajax({
				url: "/api/follows/" + followId,
				method: "DELETE"
			})
			.done(done)
			.fail(fail);
	};

	return {
		followArtist: followArtist,
		unfollowArtist: unfollowArtist
}
}();