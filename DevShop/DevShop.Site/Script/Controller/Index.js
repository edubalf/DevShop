//React.render(
//  React.createElement('h1', null, 'Hello, world!'),
//  document.getElementById('example')
//);

var nome = 'eduardo';

var CommentBox = React.createClass({
    displayName: 'CommentBox',
    render: function () {
        return (
            <div className="comment">
            <h2 className="commentAuthor">
              {this.props.author}
            </h2>
            {this.props.children}
            </div>
        );
    }
});

React.render(
  React.createElement(
    <Comment author="Pete Hunt">This is one comment</Comment>
    , null),
  document.getElementById('example')
);