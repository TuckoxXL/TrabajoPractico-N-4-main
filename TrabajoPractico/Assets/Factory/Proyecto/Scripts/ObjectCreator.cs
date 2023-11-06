using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField] private ObjectFactory objectFactory;

    [SerializeField] private Button rock;
    [SerializeField] private Button bush;
    [SerializeField] private Button tree;

    public Transform spawn;

    private void Awake()
    {
        rock.onClick.AddListener(() =>
        {
            objectFactory.CreateStuff("rock", spawn);
        });

        bush.onClick.AddListener(() =>
        {
            objectFactory.CreateStuff("bush", spawn);
        });

        tree.onClick.AddListener(() =>
        {
            objectFactory.CreateStuff("tree", spawn);
        });
    }
}
