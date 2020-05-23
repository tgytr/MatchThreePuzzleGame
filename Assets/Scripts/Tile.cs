using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class Tile : MonoBehaviour
{

	public int xIndex;
	public int yIndex;

	public Color color;

	Board m_board;

	// Use this for initialization
	void Start()
	{
		//DrawBackground();
	}

	public void Init(int x, int y, Board board)
	{
		xIndex = x;
		yIndex = y;
		m_board = board;

	}

	void DrawBackground()
	{
		this.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_Color", Color.red);
	}


	void OnMouseDown()
	{
		if (m_board != null)
		{
			m_board.ClickTile(this);
		}

	}

	void OnMouseEnter()
	{
		if (m_board != null)
		{
			m_board.DragToTile(this);
		}

	}

	void OnMouseUp()
	{
		if (m_board != null)
		{
			m_board.ReleaseTile();
		}

	}
}
